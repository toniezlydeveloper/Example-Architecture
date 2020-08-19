namespace Factory
{
    public interface IConditionChecker
    {
        #region Public Properties

        ConditionType Type { get; }

        #endregion

        #region Public Methods

        bool IsFulfilled(object value, ConditionData data);

        #endregion
    }
}