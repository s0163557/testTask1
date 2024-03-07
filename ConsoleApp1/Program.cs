using System.Text;

Console.WriteLine("Введите артикул стеклопакета:");
//Обработку входных данных на "дурака" не предполагаю, исходя из предположения что смысл тестового задания не состоит в этом.
int[] answer = findInfoSP(Console.ReadLine());
Console.WriteLine("Камерность:" + answer[0]);
Console.WriteLine("Толщина стеклопакета:" + answer[1]);
Console.WriteLine("Толщина стекла:" + answer[2]);

int[] findInfoSP(string articlSP)
{
    string[] formulaSP = articlSP.Split('/');
    int[] result = new int[3];

    //Определим камерность СП
    switch (formulaSP.Length)
    {
        case 1:
            result[0] = 0;
            break;
        case 3:
            result[0] = 1;
            break;
        case 5:
            result[0] = 2;
            break;
    }
    //Определим толщину всего СП и толщину стекла в СП
    StringBuilder sb = new StringBuilder();
    int totalThickness = 0, glassThickness = 0;
    for (int i = 0; i < formulaSP.Length; i++)
    {
        int j = 0;
        while (Char.IsDigit(formulaSP[i][j]))
        {
            sb.Append(formulaSP[i][j]);
            j++;
            if (j >= formulaSP[i].Length)
                break;
        }
        totalThickness += Int32.Parse(sb.ToString());
        if (i % 2 == 0)
            glassThickness += Int32.Parse(sb.ToString());
        sb.Clear();
    }
    //Не уверен, что термин "Толщина СП" применим к случаям, когда у нас только стекло, поэтому добавил проверку
    if (result[0] != 0)
        result[1] = totalThickness;
    result[2] = glassThickness;
    //Возвращает массив даннных, в порядке элементов: Камерность - Толщина СП - Толщина стекла.
    return result;
}