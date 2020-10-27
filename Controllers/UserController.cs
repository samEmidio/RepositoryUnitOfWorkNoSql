using Microsoft.AspNetCore.Mvc;
using RepositoryUnitOfWorkNoSql.Model;
using RepositoryUnitOfWorkNoSql.Repositories.Interface;
using RepositoryUnitOfWorkNoSql.UnitOfWork.Interface;

namespace RepositoryUnitOfWorkNoSql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser iUser;
        private readonly IUnitOfWork iUnitOfWork;
        public UserController(IUser iUser, IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
            this.iUser = iUser;

        }


        [HttpPost]
        public ActionResult createUser(User user)
        {

            //it is advisable to use Dto...

            if(user == null)
            {
                return NoContent();
            }

            iUser.Add(user);
            
            iUnitOfWork.Commit();

            return Created("",user);
        }

    }
}