namespace consumo_api_alura.Models.Interfaces;
internal interface IJsonSerializable
{
    public void ToJson(string fileName, string filePath);
}
