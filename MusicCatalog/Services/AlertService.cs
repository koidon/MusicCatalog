using MusicCatalog.Enums;

namespace MusicCatalog.Services;

public class AlertService
{
    public static string ShowAlert(Alerts obj, string message)
    {
        var alertDiv = obj switch
        {
            Alerts.Success =>
                "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " +
                message + "</a>.</div>",
            Alerts.Danger =>
                "<div class='alert alert-danger alert-dismissible' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Error!</ strong > " +
                message + "</a>.</div>",
            Alerts.Info =>
                "<div class='alert alert-info alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Info!</ strong > " +
                message + "</a>.</div>",
            Alerts.Warning =>
                "<div class='alert alert-warning alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Warning!</strong> " +
                message + "</a>.</div>",
            _ => null!
        };
        return alertDiv;
    }
}