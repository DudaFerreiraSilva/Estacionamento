const decimal PrecoPrimeiraHora = 20;
const decimal PrecoHoraPequeno = 10;
const decimal PrecoHoraGrande = 20;
const decimal PrecoDiariaPequeno = 50;
const decimal PrecoDiariaGrande = 80;
const double AdicionalValet = 0.2;
const decimal PrecoLavagemPequeno = 50;
const decimal PrecoLavagemGrande = 100;

const int TempoDiaria = 5 * 60;
const int TempoTolerancia = 5;
const int MaxTempoPermanencia = 12 * 60;

int tempoPermanencia;
string tamanho;
bool valet, lavagem;

decimal parcialEstacionamento = 0;
decimal parcialValet = 0;
decimal parcialLavagem = 0;
decimal total = 0;

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("--- Estacionamento ---\n");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("Tamanho do veículo (P/G): ");
tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();
Console.ResetColor();


if (tamanho != "P" && tamanho != "G")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Tamanho inválido.");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("Tempo de permanência (min): ");
tempoPermanencia = Convert.ToInt32(Console.ReadLine());
Console.ResetColor();

if (tempoPermanencia <= 0 || tempoPermanencia > MaxTempoPermanencia)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Tempo de permanência inválido.");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("Serviço de valet (S/N).......: ");
valet = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("Serviço de lavagem (S/N).....: ");
lavagem = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";
Console.ResetColor();

if (tempoPermanencia >= TempoDiaria)
{
    if (tamanho == "P")
    {
        parcialEstacionamento = PrecoDiariaPequeno;
    }
    else
    {
        parcialEstacionamento = PrecoDiariaGrande;
    }
}
else
{
    int horasPermanencia = (int)(tempoPermanencia / 60);
    int minutosRestantes = tempoPermanencia % 60;

    if (minutosRestantes > TempoTolerancia)
    {
        horasPermanencia++;
    }

    parcialEstacionamento = PrecoPrimeiraHora;
    int horasAdicionais = horasPermanencia - 1;

    if (horasAdicionais > 0)
    {
        if (tamanho == "P")
        {
            parcialEstacionamento += horasAdicionais * PrecoHoraPequeno;
        }
        else
        {
            parcialEstacionamento += horasAdicionais * PrecoHoraGrande;
        }
    }
}

if (valet)
{
    parcialValet = parcialEstacionamento * Convert.ToDecimal(AdicionalValet);
}

if (lavagem)
{
    if (tamanho == "P")
    {
        parcialLavagem += PrecoLavagemPequeno;
    }
    else
    {
        parcialLavagem += PrecoLavagemGrande;
    }
}

total = parcialEstacionamento + parcialValet + parcialLavagem;

Console.ForegroundColor= ConsoleColor.Green;
Console.WriteLine($"\nEstacionamento..: {parcialEstacionamento,14:C}");
Console.WriteLine($"Valet...........: {parcialValet,14:C}");
Console.WriteLine($"Lavagem.........: {parcialLavagem,14:C}");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Total...........: {total,14:C}");
Console.ResetColor();
