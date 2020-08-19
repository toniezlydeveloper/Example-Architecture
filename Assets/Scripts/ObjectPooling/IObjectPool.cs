namespace ObjectPooling
{
    public interface IObjectPool<T>
    {
        #region Public Methods

        T Get();
        void Return(T objectToReturn);

        #endregion
    }
}