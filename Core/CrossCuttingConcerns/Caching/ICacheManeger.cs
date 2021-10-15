namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);//Cache getirmek için method
        object Get(string key);//Alternatif yöntem
        void Add(string key, object value,int duration); //Key : Cache id si , value : gelen değer, duration : memoryde kalacağı süre
        bool IsAdd(string key);//Cachede varmı kontrolü
        void Remove(string key);//Cacheden silmek için method
        void RemoveByPattern(string pattern);//Neyi sileceğine dair method
    }
}
