using AccountService.GlobalExceptionFilter;
using AccountService.Models;
using AccountService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static AccountService.DataManager.SellerDataManager;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly SellerDBContext _context;
        private readonly IDataRepository<Seller,SellerDto> _dataRepository;
        private readonly ILogger<AccountController> _logger;
        public AccountController(SellerDBContext context, IDataRepository<Seller, SellerDto> dataRepository,ILogger<AccountController> logger)
        {
            _context = context;
            _dataRepository = dataRepository;
            _logger = logger;
        }
        /// <summary>
        /// Get all Seller data
        /// </summary> 
        [HttpGet]
        public IActionResult Get()
        {
            var sellers = _dataRepository.GetAll();
            _logger.LogInformation($"Getting All Seller data");
            return Ok(sellers);
        }
        /// <summary>
        /// Creates a New Seller.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /SellerRegister
        ///     {
        ///        "id": 1,
        ///        "name": "seller1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="seller"></param>
        /// <returns>A newly created SellerRegister</returns>
        /// <response code="201">Returns the newly created seller</response>
        /// <response code="400">If the seller is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SellerRegister([FromBody]Seller seller)
        {
            _logger.LogInformation("Register");
            if (seller is null)
            {
                return BadRequest("Seller is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(seller);
            _logger.LogInformation($"Succesfully Registered");
            return CreatedAtRoute("RegisterSeller", new { uname = seller.Username,pwd=seller.Password }, null);
        }
        /// <summary>
        /// Login as a specific User.
        /// </summary>
        /// <param name="uname"></param> 
        /// <param name="pwd"></param>
        [HttpGet("{uname}/{pwd}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SellerLogin(string uname, string pwd)
        {
            try 
            { 
                _logger.LogInformation("Login");
                var seller = _dataRepository.GetDto(uname, pwd);
                if (seller != null)
                {
                    return Ok(seller);
                }
                _logger.LogInformation($"Welcome {seller.Username}");
                return Ok(seller);
            }
            catch (MyAppException ex)
            {
                throw ex;
            }
        }
    }
}