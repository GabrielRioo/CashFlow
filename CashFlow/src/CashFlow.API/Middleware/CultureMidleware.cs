using System.Globalization;

namespace CashFlow.API.Middleware;

public class CultureMidleware
{
    private readonly RequestDelegate _next;
    public CultureMidleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        // Define um default para o idioma.
        var cultureInfo = new CultureInfo("en");

        // Caso venha preenchido o idioma desejado.
        if (!string.IsNullOrWhiteSpace(culture))
            cultureInfo = new CultureInfo(culture);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        // Permite o fluxo continuar.
        await _next(context);
    }
}
