using Spectre.Console;

var date = DateTime.Now;
var title = $"{date.TimeOfDay}";
var text = "";
var color = "[white]";

AnsiConsole.Clear();

while (true)
{
    var rule = new Rule($"{color}{title}[/]");

    AnsiConsole.Write(rule);
    var option = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Selecciona una opción:")
            .PageSize(10)
            .AddChoices(new[] {
            "Escribe un texto", "Cambiar color del texto", "Borrar texto",
            "Salir"
            }));


    switch (option)
    {
        case "Escribe un texto":
            if (text == "")
            {
                // AnsiConsole.Write("Vacio");
                // System.Console.WriteLine("VACIO");
                text = AnsiConsole.Ask<string>("Ingresa tu texto: ");
                AnsiConsole.Clear();
                title = text;
                rule.Title = $"{color}{title}[/]";
            }
            else
            {
                var answer = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Ya existe un texto. ¿Deseas ingresar uno nuevo?")
                        .PageSize(10)
                        .AddChoices(new[] {
                        "Si", "No",
                        }));

                if (answer == "Si")
                {
                    text = AnsiConsole.Ask<string>("Ingresa el nuevo texto: ");
                    AnsiConsole.Clear();
                    title = text;
                    rule.Title = $"{color}{title}[/]";
                }
                else
                {
                    AnsiConsole.Clear();
                }


            }
            break;

        case "Cambiar color del texto":
            var colorOption = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Selecciona una color: ")
            .PageSize(10)
            .AddChoices(new[] {
            "Blanco","Rojo", "Azul", "Verde",
            "Amarillo", "Morado", "[chartreuse2_1]Regresar al menú[/]"
            }));

            switch (colorOption)
            {
                case "Blanco":
                    AnsiConsole.Clear();
                    color = "[white]";
                    rule.Title = $"{color}{title}[/]";
                    break;
                case "Rojo":
                    AnsiConsole.Clear();
                    color = "[red]";
                    rule.Title = $"{color}{title}[/]";
                    break;
                case "Azul":
                    AnsiConsole.Clear();
                    color = "[blue]";
                    rule.Title = $"{color}{title}[/]";
                    break;
                case "Verde":
                    AnsiConsole.Clear();
                    color = "[green]";
                    rule.Title = $"{color}{title}[/]";
                    break;
                case "Amarillo":
                    AnsiConsole.Clear();
                    color = "[yellow]";
                    rule.Title = $"{color}{title}[/]";
                    break;
                case "Morado":
                    AnsiConsole.Clear();
                    color = "[purple_2]";
                    rule.Title = $"{color}{title}[/]";
                    break;
                case "[chartreuse2_1]Regresar al menú[/]":
                    AnsiConsole.Clear();
                    break;
            }
            // code block
            break;
        case "Borrar texto":

            if (String.IsNullOrEmpty(text))
            {
                var answer = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("No tienes ningún texto ingresado. ¿Deseas ingresar uno?")
                        .PageSize(10)
                        .AddChoices(new[] {
                        "Si", "No",
                        }));

                if (answer == "Si")
                {
                    text = AnsiConsole.Ask<string>("Ingresa el nuevo texto: ");
                    AnsiConsole.Clear();
                    title = text;
                    rule.Title = $"{color}{title}[/]";
                    break;
                }
                else
                {
                    AnsiConsole.Clear();
                }
            }

            AnsiConsole.Clear();
            text = "";
            title = $"{DateTime.Now.TimeOfDay}";
            rule.Title = $"{color}{title}[/]";
            break;
        case "Salir":
            AnsiConsole.Clear();
            Environment.Exit(0);
            break;
        default:
            break;
    }
}



