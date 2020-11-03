using System.Collections.Generic;
using ProcessSIM.Domain.Procedures;

namespace ProcessSIM.Domain.RandomEvents
{
    public static class RandomEventsBuilder
    {
        public static IEnumerable<RandomEvent> GetRandomEvents()
        {
            var randomEvents = new List<RandomEvent>
            {
                new RandomEvent
                {
                    EventName = "delay_between_events",
                    EventAlias = "Непредвиденная задержка",
                    DurationFrom = 1,
                    DurationTo = 60,
                    Probability = 40
                },
                new RandomEvent
                {
                    EventName = "equipment_malfunction",
                    EventAlias = "Сбой в работе оборудования",
                    DurationFrom = 5,
                    DurationTo = 40,
                    Probability = 5
                },
                new RandomEvent
                {
                    EventName = "soft_crash",
                    EventAlias = "Сбой в работе ПО",
                    DurationFrom = 1,
                    DurationTo = 10,
                    Probability = 5
                },
                new RandomEvent
                {
                    EventName = "soft_errors",
                    EventAlias = "Ошибки в ПО",
                    DurationFrom = 60,
                    DurationTo = 2880,
                    Probability = 3
                },
                new RandomEvent
                {
                    EventName = "absence_in_the_workplace",
                    EventAlias = "Отсутствие исполнителя на рабочем месте",
                    DurationFrom = 60,
                    DurationTo = 5760,
                    Probability = 5
                },
                new RandomEvent
                {
                    EventName = "control_service_delay",
                    EventAlias = "Задержка в работе службы контроля ТД",
                    DurationFrom = 360,
                    DurationTo = 5760,
                    Probability = 5
                },
            };
            
            return randomEvents;
        }
    }
}