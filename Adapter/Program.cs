using Adapter;

var employee = new Employee { basicSalary = 1000 };
var machineOperator = new MachineOperator { basicSalary = 2000 };
var salaryCalculator = new SalaryAdapter();

var salary = salaryCalculator.CalcSalary(machineOperator);
Console.WriteLine($"Total salary : {salary}");