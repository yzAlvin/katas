package beverages.supplements;

import beverages.Beverage;

public class WithCinnamon implements Beverage {
    private Beverage beverage;

    public WithCinnamon(Beverage beverage) {
        this.beverage = beverage;
    }

    @Override
    public double price() {
        return beverage.price() + 0.05;
    }
}