using FintachartsAPI.Domain.Helpers;
using System.Net;

namespace FintachartsAPI.Domain.Exceptions;

[HttpStatusCode(HttpStatusCode.BadRequest)]
public class UpdateFailedException() : FintachartsException(StatusCodes.UpdateFailed);