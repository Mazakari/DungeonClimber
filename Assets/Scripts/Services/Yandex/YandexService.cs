public class YandexService : IYandexService
{
    public YandexAPI API { get; }

    public YandexService(YandexAPI yandexAPI)
    {
        API = yandexAPI;
    }
}
