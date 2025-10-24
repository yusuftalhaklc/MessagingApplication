using MessagingApplication.Models;
using MessagingApplication.Repositories;
using MessagingApplication.Services;
using System;
using System.Collections.Generic;

internal class Program
{

    // User(Id,Username,Password,Email,EmailConfirm,FirstName,LastName,CreatedDate)
    // Id : Sadece okunabilir olacak. Tip Guid olsun.
    // Username bos gecilemez, 3 ile 20 karakter arasinda olabilir. Eger fazla olursa kirpilsin, eksik kalirsa sol tarafi * sembolu ile doldurulsun.
    // Password en az 8 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
    // Email : Bos gecilemez olsun.
    // EmailConfirm : Sadece okunabilir olsun. Email ile ayni degeri dondursun.
    // FirstName ve LastName : Bos gecilemez.

    // Message(Id,Content,SenderId,RecevierId,CreatedDate)
    // Id : Sadece okunabilir olacak. Tip Guid olsun.
    // Content : En az 1 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
    // SenderId ve RecevierId : Bos gecilemez.
    // CreatedDate : Sadece okunabilir olsun. Mesajin olusturuldugu tarihi dondursun.

    // Generic Repository(CRUD) yapisi olusturunuz. Static bir listeyi depo haline getiriniz.
    // Kullanici uyelik olusturur.
    // Kullanici giris yapar.
    // Belirtilen kullanici id veya kullanici adi ile mesaj gonderir.
    // Kullanici cikis yapar.
    // Diger kullanici giris yapip gelen mesajlari gorur.
    // Cevap verir.

    private static void Main()
    {

        var userRepo = new UserRepository();
        var msgRepo = new MessageRepository();

        var userService = new UserService(userRepo);
        var messageService = new MessageService(msgRepo);

        var currentUser = userService.CurrentUser;

        while (true)
        {
            Console.WriteLine("======MESSAGING APPLICATON======");
            if (currentUser == null)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Firstname: ");
                        var firstName = Console.ReadLine();

                        Console.Write("LastName: ");
                        var lastName = Console.ReadLine();

                        Console.Write("Username: "); 
                        var username = Console.ReadLine();

                        Console.Write("Password: "); 
                        var password = Console.ReadLine();

                        Console.Write("Email: "); 
                        var email = Console.ReadLine();

                        try
                        {
                            userService.Register(username, password, email, firstName, lastName);
                            Console.WriteLine("Register is Successfull!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }

                        break;
                    case "2":
                        Console.Write("Username: "); 
                        username = Console.ReadLine();

                        Console.Write("Password: "); 
                        password = Console.ReadLine();

                        try
                        {
                            userService.Login(username, password);
                            currentUser = userService.CurrentUser;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }

                        break;

                    case "3":
                        return;
                    default:
                        Console.WriteLine("Wrong choice");
                        return;
                }
            } else
            {
                Console.WriteLine($"======WELCOME {currentUser} ======");
                Console.WriteLine("1. List User");
                Console.WriteLine("2. Send Message");
                Console.WriteLine("3. Get Messages");
                Console.WriteLine("4. Exit");
                Console.Write("choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("====== Users ======");
                        foreach (var user in userService.GetUsers())
                        {
                            Console.WriteLine("\t "+ user);
                        }
                        break;
                    case "2":
                        Console.Write("Enter Receiver Id: ");
                        bool ok = Guid.TryParse(Console.ReadLine(), out Guid recieverId);
                        if (!ok)
                        {
                            Console.WriteLine("Wrong GUID for reciever id.");
                            return;
                        }

                        Console.Write("Your message: ");
                        string content = Console.ReadLine();

                        try
                        {
                            messageService.SendMessage(currentUser.Id, recieverId, content);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error: " + ex.Message);
                        }

                        break;
                    case "3":
                        Console.Write("Enter Receiver Id: ");
                        bool success = Guid.TryParse(Console.ReadLine(), out Guid chatRecieverId);
                        if (!success)
                        {
                            Console.WriteLine("Wrong GUID for reciever id.");
                            return;
                        }

                        try
                        {
                            var messages = messageService.GetMessages(currentUser.Id, chatRecieverId);

                            foreach (Message message in messages)
                            {
                                if (message != null)
                                    Console.WriteLine("\t- " + message);
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error: " + ex.Message);
                        }

                        break;
                    case "4":
                        currentUser = null;
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        return;
                }
            }

        }

    }
}