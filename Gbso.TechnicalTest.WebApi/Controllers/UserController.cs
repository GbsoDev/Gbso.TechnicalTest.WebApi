using Gbso.TechnicalTest.Cl.BllService;
using Gbso.TechnicalTest.Cl.Exception;
using Gbso.TechnicalTest.Dto;
using Gbso.TechnicalTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Gbso.TechnicalTest.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : BaseController
	{
		private IUserService userService => _userService.Value;
		private readonly Lazy<IUserService> _userService;

		public UserController(IServiceProvider serviceProvider, Lazy<IUserService> userService) : base(serviceProvider)
		{
			this._userService = userService;
		}


		[HttpPost]
		[ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Post([FromBody] UserDto userDto)
		{
			var user = Mapper.Map<UserDto, User> (userDto);
			var userResult = userService.Register(user);
			return new OkObjectResult(userResult);
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Get()
		{
			try
			{
				var users = userService.List();
				var userResult = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
				return new OkObjectResult(userResult);
			}
			catch (ValidateException ex)
			{
				return new NotFoundObjectResult(ex.Message);
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ById(int id)
		{
			try
			{
				var user = userService.GeyById(id);
				var userResult = Mapper.Map<User, UserDto>(user);
				return new OkObjectResult(userResult);
			}
			catch (ValidateException ex)
			{
				return new NotFoundObjectResult(ex.Message);
			}
		}

		[HttpPut]
		[ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Put([FromBody] UserDto userDto)
		{
			var user = Mapper.Map<UserDto, User>(userDto);
			var userResult = userService.Update(user);
			return new OkObjectResult(userResult);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Delete(int id)
		{
			userService.Delete(id);
			return new OkResult();
		}
	}
}
