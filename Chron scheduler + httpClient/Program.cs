
using Cronos;
class Program
{
    private static CronExpression _cronExpression;
    private static DateTime _nextRunTime;
    /// <summary>
    /// Her setter vi opp en CRON job med å bruke CRONOS sin CronExpression string, for å kjøre en funksjon på et satt tidspunkt. </br>
    /// en Cron string er delt opp i seks "fields" representert som  * * * * * *.</br>
    /// Det som gjelder er følgende:
    /// * * * * * *</br>
    /// | | | | | |</br>
    /// | | | | | +----Ukedag, representert med tall (0-7) hvor søndag er både 0 og 7.<br>
    /// | | | | +------Måned, (1-12) 1 er januar, desember er 12.</br>
    /// | | | +--------Dato, (1-31) representerer hvilken dato i måneden det er.</br>
    /// | | +----------Time, (0-23) Representerer hvilken time funksjonen skal kjøres i. </br>
    /// | +------------Minutt, (0-59) represenrerer hvilke minutt det skal kjøres på</br>
    /// +--------------Sekund, (0-59) representerer hvilke sekund det skal kjøres på. </br>
    /// </br>
    /// I funksjonen under har vi en cronstring som ser slik ut: */1 * * * *. Den sier "Repeter hvert minutt." 1 tallet på andre posisjon betyr 1 minutt.</br>
    /// Det blir tolket av _cronExpression.GetNextOccurence som "Kjør igjen om ett minutt fra nå." </br>
    /// Vi kunne kjørt funksjonen vår hver time ved å skifte cronExpression til: * */1 * * * </br>
    /// Eller hver måned hved å skifte til: * * * * /1 * </br>
    /// Eller hver mandag klokken åtte om morningen: 0 0 8 * * 1</br>
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static async Task Main(string[] args)
    {
        string cronExpression = "*/1 * * * * ";
        _cronExpression = CronExpression.Parse(cronExpression);
        _nextRunTime = _cronExpression.GetNextOccurrence(DateTime.UtcNow, TimeZoneInfo.Local) ?? DateTime.MaxValue;
        var cts = new CancellationTokenSource();
        var task = RunScheduledTask(cts.Token);
        Console.WriteLine("Cron Scheduler started, press any key to exit...");
        Console.ReadLine();
        cts.Cancel();
        await task;
    }
    /// <summary>
    /// Funksjon som tar inn en cancellationToken.</br>
    /// Kjører en async loop mens cancelationToken fremdeles er aktiv. </br>
    /// 
    /// </br>
    /// OPS OPS!
    /// </br>
    /// </br>
    /// Når cancellationToken sender en cancelrequest så er det en TaskCanceledException!
    /// </br>
    /// En annen ting å bite merke i er når den skjekker om "now" er rette tiden å kjøre en cron job på, så er "delayen" til neste check hardcoded. </br>
    /// Her kan det være lurt å lage en dynamisk "delay" som sammenligner now med _nextRunTime for å finne neste gang programmet bør skjekke.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task RunScheduledTask(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            DateTime now = DateTime.UtcNow;
            if (now >= _nextRunTime)
            {
                await ExcecuteTask();
                _nextRunTime = _cronExpression.GetNextOccurrence(DateTime.UtcNow, TimeZoneInfo.Local) ?? DateTime.MaxValue;
            }
            await Task.Delay(1000, cancellationToken);
        }
    }
    /// <summary>
    /// Funksjonen som kjøres i async Chronjob.</br>
    /// I dette tilfellet en enkel fetch request til jsonplaceholder. </br>
    /// </summary>
    /// <returns></returns>
    private static async Task ExcecuteTask()
    {
        using (HttpClient client = new())
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/todos/1";
                HttpResponseMessage response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
