using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.Extensions;

public static class Extension
{
    public static IActionResult ActionResultFromBool(this ControllerBase cb, bool value)
    {
        return value ? cb.Ok() : cb.BadRequest();
    }
}
