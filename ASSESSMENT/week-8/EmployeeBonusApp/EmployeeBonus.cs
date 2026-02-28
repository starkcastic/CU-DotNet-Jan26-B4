using System;

namespace EmployeeBonusApp
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public EmployeeBonus(decimal baseSalary, int rating, int experience,
                             decimal multiplier, double attendance)
        {
            BaseSalary = baseSalary;
            PerformanceRating = rating;
            YearsOfExperience = experience;
            DepartmentMultiplier = multiplier;
            AttendancePercentage = attendance;
        }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0;

                decimal bonus = 0m;

                // Step 1: Rating Bonus
                switch (PerformanceRating)
                {
                    case 5: bonus += 0.25m * BaseSalary; break;
                    case 4: bonus += 0.18m * BaseSalary; break;
                    case 3: bonus += 0.12m * BaseSalary; break;
                    case 2: bonus += 0.05m * BaseSalary; break;
                    case 1: break;
                    default:
                        throw new InvalidOperationException("Invalid performance rating.");
                }

                // Step 2: Experience Bonus
                if (YearsOfExperience > 10)
                    bonus += 0.05m * BaseSalary;
                else if (YearsOfExperience > 5)
                    bonus += 0.03m * BaseSalary;

                // Step 3: Attendance Penalty
                if (AttendancePercentage < 85)
                    bonus *= 0.8m;

                // Step 4: Department Multiplier
                bonus *= DepartmentMultiplier;

                // Step 5: Cap at 40%
                decimal maxBonus = 0.4m * BaseSalary;
                if (bonus > maxBonus)
                    bonus = maxBonus;

                // Step 6: Tax
                if (bonus > 300000)
                    bonus *= 0.7m;        // 30% tax
                else if (bonus <= 150000)
                    bonus *= 0.9m;        // 10% tax
                else
                    bonus *= 0.8m;        // 20% tax

                return Math.Round(bonus, 2);
            }
        }
    }
}