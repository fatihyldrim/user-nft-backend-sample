using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Commands.NFTTransaction
{
    public class NFTTransactionRequest : IRequest<NFTTransactionResponse>
    {
        public string? WebhookId { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string? Type { get; set; }
        public Event? Event { get; set; }
    }

    public class Event
    {
        public string? Network { get; set; }
        public Activity[] Activity { get; set; } = null!;
    }

    public class Activity
    {
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public string? ContractAddress { get; set; }
        public string? BlockNum { get; set; }
        public string? Hash { get; set; }
        public string? Erc721TokenId { get; set; }
        public string? Category { get; set; }
        public Log? Log { get; set; }
    }

    public class Log
    {
        public string? Address { get; set; }
        public string[]? Topics { get; set; }
        public string? Data { get; set; }
        public string? BlockNumber { get; set; }
        public string? TransactionHash { get; set; }
        public string? TransactionIndex { get; set; }
        public string? BlockHash { get; set; }
        public string? LogIndex { get; set; }
        public bool Removed { get; set; }
    }
}

