﻿
namespace CashFlow.Communication.Responses
{
    public class ResposnseGetExpensesJson
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}
