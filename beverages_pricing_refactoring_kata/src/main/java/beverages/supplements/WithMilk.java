package beverages.supplements;

import beverages.Beverage;

public class WithMilk implements Beverage {
    private Beverage beverage;

    public WithMilk(Beverage beverage) {
        this.beverage = beverage;
    }

    @Override
    public double price() {
        return beverage.price() + 0.10;
    }
}