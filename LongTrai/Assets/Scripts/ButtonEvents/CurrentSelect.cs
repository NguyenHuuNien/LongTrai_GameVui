public class CurrentSelect
{
    private static EItems items;
    public static void changeItems(EItems newItem){
        items = newItem;
    }
    public static EItems getCurrentItem(){
        return items;
    }

}
