
namespace Domain.Constant
{
    public class Constants
    {
        public enum Actions
        {
            Create = 1,
            Update = 2
        }

        public enum MessageTypes
        {
            Nothing = 0,
            Error = 1,
            Success = 2,
        }

        public enum ProcessStatuses
        {
            Başlamadı = 0,
            NormalYürüyor = 1,
            Bitti = 2
        }

        public enum AgreementTypes
        {
            Kamuİştirakli = 0,
            Devletİştirakli = 1
        }
    }
}