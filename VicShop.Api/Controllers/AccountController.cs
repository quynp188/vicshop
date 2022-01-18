 
namespace VicShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public AccountController(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        this._userManager = userManager;
        this._configuration = configuration;
    }
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Authenticate([FromBody] AccountLogin accountLogin)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        try
        {
            var user = await _userManager.FindByEmailAsync(accountLogin.Email);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tài khoản không tồn tại");
            }
            if (!(await _userManager.CheckPasswordAsync(user, accountLogin.Password)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Thông tin đăng nhập không đúng");
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName), new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var jwtConfig = this._configuration.GetSection("JWT").Get<JsonWebTokenModel>();
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig!.SecretKey));
            var token = new JwtSecurityToken(issuer: jwtConfig.ValidIssuer, audience: jwtConfig.ValidAudience,
                expires: DateTime.Now.AddHours(jwtConfig.ExpireTime), claims: authClaims, signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                Email = user.Email,
                FullName = user.FullName
            });
        }
        catch (SqlException ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        var userExists = await _userManager.FindByNameAsync(model.Email);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response("Tài khoản đã tồn tại"));
        AppUser user = new AppUser()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.UserName
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response("Lỗi tạo tài khoản vui lòng thử lại sau"));
        return Ok(new Response("Tạo tài khoản thành công"));
    }
}