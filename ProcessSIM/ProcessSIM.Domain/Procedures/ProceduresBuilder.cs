using System.Collections.Generic;

namespace ProcessSIM.Domain.Procedures
{
    public static class ProceduresBuilder
    {
        public static IEnumerable<Procedure> GetProcedures()
        {
            var procedures = new List<Procedure>
            {
                new Procedure
                {
                    Name = "source_data_analysis",
                    Alias = "Анализ исходных данных",
                    ProgressFunction = "([x]*[human_experience])/(60*[design_object_complexity])",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"absence_in_the_workplace"},
                    ResourcesList = "Исполнитель"
                },
                new Procedure
                {
                    Name = "typical_process_analysis",
                    Alias = "Анализ типовых ТП",
                    ProgressFunction = "([x]*[cad_level])/(10*[design_object_complexity]*(2048/[ram]))",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"soft_errors", "soft_crash", "equipment_malfunction", "delay_between_events"},
                    ResourcesList = "САПР, Компьютер"
                },
                new Procedure
                {
                    Name = "process_tree_creation",
                    Alias = "Формирование дерева ТП",
                    ProgressFunction = "([x]*([cad_level]+[human_experience]))/(240*[design_object_complexity]*(2048/[ram])*2)",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"soft_errors", "soft_crash", "equipment_malfunction", "delay_between_events"},
                    ResourcesList = "Исполнитель, САПР, Компьютер"
                },
                new Procedure
                {
                    Name = "process_path_creation",
                    Alias = "Формирование технологического маршрута",
                    ProgressFunction = "([x]*[cad_level])/(5*[design_object_complexity]*(2048/[ram]))",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"soft_errors", "soft_crash", "equipment_malfunction", "delay_between_events"},
                    ResourcesList = "САПР, Компьютер"
                },
                new Procedure
                {
                    Name = "process_rationing",
                    Alias = "Нормирование технологических процессов",
                    ProgressFunction = "([x]*[human_experience])/(120*[design_object_complexity])",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"soft_errors", "soft_crash", "equipment_malfunction", "delay_between_events"},
                    ResourcesList = "Исполнитель"
                },
                new Procedure
                {
                    Name = "documentation_creation",
                    Alias = "Формирование технологической документации",
                    ProgressFunction = "([x]*[cad_level]*[print_speed])/(5*[design_object_complexity]*(2048/[ram])*[print_speed]+[cad_level]*[documents_count]*60)",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        },
                        new ProcedureParameter
                        {
                            Name = "documents_count", Alias = "Количество технологических документов"
                        }
                    },
                    PossibleEvents = new [] {"soft_errors", "soft_crash", "equipment_malfunction", "delay_between_events"},
                    ResourcesList = "САПР, Компьютер, Принтер"
                },
                new Procedure
                {
                    Name = "safety_requirements_identification",
                    Alias = "Определение требований ТБ",
                    ProgressFunction = "([x]*[human_experience])/(60*[design_object_complexity])",
                    Parameters = new List<ProcedureParameter> {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"delay_between_events"},
                    ResourcesList = "Исполнитель"
                },
                new Procedure
                {
                    Name = "cost_effect_calculation",
                    Alias = "Расчёт экономической эффективности",
                    ProgressFunction = "([x]*[human_experience])/(120*[design_object_complexity])",
                    Parameters = new List<ProcedureParameter> {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"delay_between_events"},
                    ResourcesList = "Исполнитель"
                },
                new Procedure
                {
                    Name = "documentation_alignment_services",
                    Alias = "Согласование документации со службами контроля",
                    ProgressFunction = "[x]/(4320*[design_object_complexity])",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        },
                    },
                    PossibleEvents = new [] {"control_service_delay", "delay_between_events"},
                    ResourcesList = "–"
                },
                new Procedure
                {
                    Name = "documentation_alignment_customer",
                    Alias = "Согласование документации с заказчиком",
                    ProgressFunction = "[x]/(4320*[design_object_complexity])",
                    Parameters = new List<ProcedureParameter>
                    {
                        new ProcedureParameter
                        {
                            Name = "design_object_complexity", Alias = "Сложность объекта проектирования"
                        }
                    },
                    PossibleEvents = new [] {"delay_between_events"},
                    ResourcesList = "–"
                }
            };
            
            return procedures;
        }
    }
}