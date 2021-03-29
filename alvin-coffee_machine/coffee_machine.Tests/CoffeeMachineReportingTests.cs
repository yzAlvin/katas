using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;
using Moq;
using Xunit;

namespace coffee_machine.Tests
{
    public class CoffeeMachineReportingTests
    {
        private IEmailNotifier _dummyEmailNotifier = Mock.Of<IEmailNotifier>();
        private IBeverageQuantityChecker _dummyBeverageQuantityChecker = Mock.Of<IBeverageQuantityChecker>();
        
        [Fact]
        public void Coffee_Machine_ReportingTool_Reports_0_At_Start()
        {
        //Given
            CoffeeMachine coffeeMachine = new CoffeeMachine(_dummyEmailNotifier, _dummyBeverageQuantityChecker);
            var expectedReport = new StringBuilder("The total of each drinks made are: \n");
            expectedReport.AppendLine("O: 0");
            expectedReport.AppendLine("T: 0");
            expectedReport.AppendLine("H: 0");
            expectedReport.AppendLine("C: 0");
            expectedReport.AppendLine("The coffee machine has earned: $0");
        //When
        
        //Then
            Assert.Equal(expectedReport.ToString(), coffeeMachine.Report());
        }

        [Fact]
        public void Coffee_Machine_ReportingTool_Tracks_Drinks()
        {
        //Given
            CoffeeMachine coffeeMachine = new CoffeeMachine(_dummyEmailNotifier, _dummyBeverageQuantityChecker);
            coffeeMachine.GiveCommand("T::", 1);
            coffeeMachine.GiveCommand("Th::", 1);
            coffeeMachine.GiveCommand("O::", 1);
            coffeeMachine.GiveCommand("O::", 0);
            coffeeMachine.GiveCommand("H::", 0);
            coffeeMachine.GiveCommand("Ch::", 1);
            var expectedReport = new StringBuilder("The total of each drinks made are: \n");
            expectedReport.AppendLine("O: 1");
            expectedReport.AppendLine("T: 2");
            expectedReport.AppendLine("H: 0");
            expectedReport.AppendLine("C: 1");
            expectedReport.AppendLine("The coffee machine has earned: $2.0");
        //When

        //Then
            Assert.Equal(expectedReport.ToString(), coffeeMachine.Report());
        }
    }
}