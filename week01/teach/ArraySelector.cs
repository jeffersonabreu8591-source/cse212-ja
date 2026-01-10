using System.ComponentModel;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int indice1 = 0;
        int indice2 = 0;
        List<int> resultado = new();
        for ( int i=0; i < select.Length; i++ )
        {
            int valor = select[i];
            if (valor == 1)
            {
                resultado.Add(list1[indice1]);
                indice1++;
            } 
            else
            {
                resultado.Add(list2[indice2]);
                indice2++;
            }
        }
        return resultado.ToArray();
    }
}