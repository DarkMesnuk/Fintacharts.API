using FintachartsAPI.Domain.Helpers;
using System.Net;

namespace FintachartsAPI.Domain.Exceptions;

[HttpStatusCode(HttpStatusCode.BadRequest)]
public class DeleteFailedException() : FintachartsException(StatusCodes.DeleteFailed);