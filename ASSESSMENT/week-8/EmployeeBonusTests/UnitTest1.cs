using NUnit.Framework;
using EmployeeBonusApp;

namespace EmployeeBonusTests
{
    public class Tests
    {
        [Test]
        public void NormalHighPerformer()
        {
            var emp = new EmployeeBonus(500000m, 5, 6, 1.1m, 95);
            Assert.That(emp.NetAnnualBonus, Is.EqualTo(123200.00m));
        }

        [Test]
        public void AttendancePenalty()
        {
            var emp = new EmployeeBonus(400000m, 4, 8, 1.0m, 80);
            Assert.That(emp.NetAnnualBonus, Is.EqualTo(60480.00m));
        }

        [Test]
        public void CapTriggered()
        {
            var emp = new EmployeeBonus(1000000m, 5, 15, 1.5m, 95);
            Assert.That(emp.NetAnnualBonus, Is.EqualTo(280000.00m));
        }

        [Test]
        public void ZeroSalary()
        {
            var emp = new EmployeeBonus(0m, 5, 10, 1.2m, 100);
            Assert.That(emp.NetAnnualBonus, Is.EqualTo(0m));
        }

        [Test]
        public void LowPerformer()
        {
            var emp = new EmployeeBonus(300000m, 2, 3, 1.0m, 90);
            Assert.That(emp.NetAnnualBonus, Is.EqualTo(13500.00m));
        }

        [Test]
        public void InvalidRating()
        {
            var emp = new EmployeeBonus(300000m, 7, 3, 1.0m, 90);
            Assert.Throws<InvalidOperationException>(() => {
                var bonus = emp.NetAnnualBonus;
            });
        }
    }
}