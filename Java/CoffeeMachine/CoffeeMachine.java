import java.util.Scanner;

enum State {
    BUY, FILL, TAKE, REMAINING, EXIT
}

public class CoffeeMachine {
    private int countWater;
    private int countMilk;
    private int countCoffeeBeans;
    private int countPaperCups;
    private int countMoney;

    public CoffeeMachine(int countWater, int countMilk, int countCoffeeBeans, int countPaperCups, int countMoney) {
        this.countWater = countWater;
        this.countMilk = countMilk;
        this.countCoffeeBeans = countCoffeeBeans;
        this.countPaperCups = countPaperCups;
        this.countMoney = countMoney;
    }

    public void showInfo() {
        System.out.println();
        System.out.println("The coffee machine has:");
        System.out.println(countWater + " of water");
        System.out.println(countMilk + " of milk");
        System.out.println(countCoffeeBeans + " of coffee beans");
        System.out.println(countPaperCups + " of disposable cups");
        System.out.println("$"+countMoney + " of money" );
        System.out.println();
    }

    public boolean checkResource(int needWater, int needMilk, int needcofeeBeans, int cups)
    {
        boolean check = false;
        String result = "Sorry, not enough";
        if (countWater < needWater) {
            result += " water!";
        } else if (countMilk < needMilk){
            result += " milk!";
        } else if (countCoffeeBeans < needcofeeBeans) {
            result += " coffee beans!";
        } else if (cups <= 0) {
            result += " disposable cups";
        } else {
            result = "I have enough resources, making you a coffee!";
            check = true;
        }
        System.out.println(result);
        return check; 
    }

    public void fillOfMachine() {
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("Write how ml of water do you want to add:");
        countWater += scanner.nextInt();
        System.out.println("Write how ml of milk do you want to add:");
        countMilk += scanner.nextInt();
        System.out.println("Write how many grams of coffee beans do you want to add:");
        countCoffeeBeans += scanner.nextInt();
        System.out.println("Write how many disposable of coffee do you want to add:");
        countPaperCups += scanner.nextInt();
        System.out.println();
    }

    public int takeOfMoney(int countMoney) {
        System.out.println("I gave you " + countMoney + "$");
        System.out.println();
        return 0;
    }

    public void buyOfCoffee() {
        int needWater = 0;
        int needcofeeBeans = 0;
        int giveMoney = 0;
        int needMilk = 0;
        System.out.println();
        System.out.println("What do you want to buy? 1 - espresso, 2 - latte, 3 - cappuccino back - to main menu");
        Scanner scanner = new Scanner(System.in);
        String choose = scanner.nextLine();
        switch (choose) {
            case "1":
                needWater = 250;
                needcofeeBeans = 16; 
                giveMoney = 4;
                break;
            case "2":
                needWater = 350;
                needMilk = 75;
                needcofeeBeans = 20; 
                giveMoney = 7;
                break;
            case "3":
                needWater = 200;
                needMilk = 100;
                needcofeeBeans = 12; 
                giveMoney = 6;
                break;
            case "back":
                return ; // return to main menu 
            default:
                System.out.println("You don't choose coffee");
                break;
        }
        if (checkResource(needWater, needMilk, needcofeeBeans, countPaperCups)) {
            countWater -= needWater;
            countMilk -= needMilk;
            countCoffeeBeans -= needcofeeBeans;
            countMoney += giveMoney;
            countPaperCups--;
        }
        System.out.println();  
    }
    
    public boolean workMachine(State userState) {
        switch (userState) {
            case BUY:
                buyOfCoffee();
                break;
            case FILL:
                fillOfMachine();
                break;
            case TAKE:
                countMoney = takeOfMoney(countMoney);
                break;
            case REMAINING:
                showInfo();
                break;
            case EXIT:
                return false;
            default:
                System.out.println("Error: not found command");
                break;
        }
        return true;
    }
}


//learn exception */

class MainClass {
    public static void main(String[] args) {
        boolean repeat = true;
        Scanner scanner = new Scanner(System.in);
        CoffeeMachine coffeeMachine = new CoffeeMachine(400, 540, 120, 9, 550);
        State currentState = State.EXIT;
        while (repeat) {
         System.out.println("Write action (buy, fill, take, remaining, exit):");
         String choose = scanner.nextLine();
         currentState = State.valueOf(choose.toUpperCase());
         repeat = coffeeMachine.workMachine(currentState);
        }
        scanner.close();    
    }
}
