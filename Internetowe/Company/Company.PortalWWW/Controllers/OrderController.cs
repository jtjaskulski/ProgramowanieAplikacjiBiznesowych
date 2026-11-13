using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Company.PortalWWW.Controllers;

public class OrderController(CompanyContext context, ILogger<OrderController>  logger) : Controller
{
    
}