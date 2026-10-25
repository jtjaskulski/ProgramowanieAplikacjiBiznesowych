export type RootStackParamList = {
    Home: undefined;
    Details: {
        itemId: number;
        itemName: string;
    };
    Profile: {
        userId: number;
    };
};