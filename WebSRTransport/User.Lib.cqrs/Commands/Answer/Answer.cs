namespace Common.lib.cqrs.commands.Commands.Answer
{
    public class Answer<TItem>
    {
        public TItem Item { get; set; }
        public AnswerState State { get; set; }

        public Answer(TItem item, AnswerState state)
        {
            Item = item;
            State = state;
        }
    }

    public enum AnswerState
    {
        Created = 201,
        Done = 200,
        Deleted = 410
    }
}
