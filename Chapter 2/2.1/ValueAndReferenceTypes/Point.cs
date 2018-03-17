namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Struktury mogą zawierać:
    /// - stałe, pola, metody, właściwości, indeksatory, zdarzenia, konstruktory, 
    /// Nie można tworzyć w strukturach:
    /// - konstruktora bezparametrowego, destruktora
    /// Nie można inicjować pół w chwili ich deklaracji
    /// Struktury nie obsługują dzieciczenia
    /// Mogą implementować interefejsy
    /// Możliwe modyfikatory dostępu struktury to:
    /// - new, public, private, protected, internal
    /// </summary>
    public struct PointStruct
    {
        public int x, y;

        public PointStruct(int x1, int y1)
        {
            x = x1;
            y = y1;
        }
    }
    
    /// <summary>
    /// Możliwe modyfikatory dostępu to:
    /// - new, abstract, public, private, sealed, protected, internal
    /// Mogę posiadać bezparametrowy konstruktor
    /// Mogą dziedziczyć tylko od jednej klasy
    /// Mogą implementować wiele interfejsów
    /// 
    /// Należy myśleć o klasach zadając sobie pytanie, co mogą robić, a nie jakie dane mają prezentować
    /// </summary>
    public class PointClass
    {
        public int x, y;

        public PointClass(int x1, int y1)
        {
            x = x1;
            y = y1;
        }
    }

}
