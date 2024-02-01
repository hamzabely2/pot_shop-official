using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Order;

namespace back_end.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleString.User)]
    public class OrderController : Controller
    {




    }

}
