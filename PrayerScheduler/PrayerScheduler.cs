namespace PrayerScheduler;

public class PrayerScheduler
{
    public int NumDailyPrayers => DailyPrayers.Count;
    public int NumNonDailyPrayers => NonDailyPrayers.Count;

    public List<Prayer> DailyPrayers { get; } = new();

    private Queue<Prayer> nonDailyPrayersQueue = new(); 
    public List<Prayer> NonDailyPrayers
    {
        get
        {
            return nonDailyPrayersQueue.ToList();
        }
    }

    public List<Prayer> AnsweredPrayers { get; } = new();

    public PrayerScheduler()
    {
    }

    public void AddPrayer(Prayer prayer)
    {
        if (DailyPrayers.Any(p => p.ID == prayer.ID) || nonDailyPrayersQueue.Any(p => p.ID == prayer.ID) || AnsweredPrayers.Any(p => p.ID == prayer.ID))
        {
            throw new DuplicateIDException();
        }
        if (prayer.IsAnswered)
        {
            AnsweredPrayers.Add(prayer);
            return;
        }
        if (prayer.IsDaily)
        {
            DailyPrayers.Add(prayer);
            return;
        }
        nonDailyPrayersQueue.Enqueue(prayer);
    }

    public void AnswerPrayer(int id)
    {
        var dailyPrayer = DailyPrayers.Find( p => p.ID == id);
        if (dailyPrayer is not null)
        {
            dailyPrayer.IsAnswered = true;
            DailyPrayers.Remove(dailyPrayer);
            AnsweredPrayers.Add(dailyPrayer);   
            return;
        }

        int prayersToCheck = nonDailyPrayersQueue.Count;
        for (int i = 0; i < prayersToCheck; i++)
        {
            var nonDailyPrayer = nonDailyPrayersQueue.Dequeue();
            if (nonDailyPrayer.ID == id)
            {
                nonDailyPrayer.IsAnswered = true;
                AnsweredPrayers.Add(nonDailyPrayer);
            }
            else
            {
                nonDailyPrayersQueue.Enqueue(nonDailyPrayer);
            }
        }
    }

    public List<Prayer> GetPrayers(int numPrayers)
    {
        List<Prayer> prayers = [ ..DailyPrayers];
        int spotsRemaining = numPrayers - DailyPrayers.Count;
        foreach (var p in prayers)
        {
            p.LastPrayed = DateTime.Now;
        }
        
        while (spotsRemaining > 0)
        {
            var nonDailyPrayer = nonDailyPrayersQueue.Dequeue();
            prayers.Add(nonDailyPrayer);
            nonDailyPrayer.LastPrayed = DateTime.Now;
            spotsRemaining--;
            nonDailyPrayersQueue.Enqueue(nonDailyPrayer);
        }

        return prayers;
    }
}


