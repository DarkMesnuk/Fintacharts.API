using FintachartsAPI.Domain.Helpers;
using System.Net;

namespace FintachartsAPI.Domain.Exceptions;

[HttpStatusCode(HttpStatusCode.BadRequest)]
public class CreationFailedException(string entityType = "") : FintachartsException(StatusCodes.CreationFailed, entityType);