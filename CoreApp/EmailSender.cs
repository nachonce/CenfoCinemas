using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSender
{
    public static async Task SendWelcomeEmail(string toEmail, string userName)
    {
      var apiKey = "";



        var client = new SendGridClient(apiKey);

        var from = new EmailAddress("jbolanosr@ucenfotec.ac.cr", "Mi App");
        var subject = "¡Bienvenido a nuestra plataforma!";
        var to = new EmailAddress(toEmail, userName);
        var plainText = $"Hola {userName}, ¡gracias por registrarte!";
        var html = $"<strong>Hola {userName}, gracias por unirte a nuestra app </strong>";

        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainText, html);
        await client.SendEmailAsync(msg);


        var response = await client.SendEmailAsync(msg);


        Console.WriteLine("Status: " + response.StatusCode);


      
        string body = await response.Body.ReadAsStringAsync();
        Console.WriteLine("Status: " + response.StatusCode);
        Console.WriteLine("Response body: " + body); //

    }

    public static async Task SendNewMovieEmail(string Email, string movieTitle) {

        var apiKey = "";



        var client = new SendGridClient(apiKey);


        var from = new EmailAddress("nacho3_6@hotmail.com", "Mi App");
        var subject = "¡Nueva Pelicula!";
        var to = new EmailAddress(Email);
        var plainText = $"Ya esta disponible nuestra pelicula : {movieTitle}!";
        var html = $"<strong>Tenemos una nueva Pelicula! <br> Título: {movieTitle} </strong>";

        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainText, html);
        await client.SendEmailAsync(msg);
        var response = await client.SendEmailAsync(msg);
        Console.WriteLine("Status: " + response.StatusCode);



        


    }
}