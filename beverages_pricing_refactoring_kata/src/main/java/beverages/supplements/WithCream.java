package beverages.supplements;

import beverages.Beverage;

public class WithCream implements Beverage {
    private Beverage beverage;

    public WithCream(Beverage beverage) {
        this.beverage = beverage;
    }

    @Override
    public double price() {
        return beverage.price() + 0.15;
    }
}