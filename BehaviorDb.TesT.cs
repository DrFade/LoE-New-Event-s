using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb // goin back to doing behaviors
    {
        private _ TEST1 = () => Behav()
            .Init("TESTBOSS",
                new State(
                    new State("waiting",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "1")
                        ),
                    new State("1",
                        new Prioritize(
                            new Follow(1.1),
                            new StayCloseToSpawn(1, range: 10)
                            ),
                        new Shoot(10, predictive: 1, projectileIndex: 1, coolDown: 800),
                        new HpLessTransition(0.8, "blaarg1")
                        ),
                    new State("blaarg1",
                        new Prioritize(
                            new Follow(0.1)
                            ),
                        new Grenade(5, 100, 10),
                        new Shoot(20, predictive: 1, projectileIndex: 0, coolDown: 100),
                        new HpLessTransition(0.6, "blaarg2")
                        ),
                    new State("blaarg2",
                        new Prioritize(
                            new Follow(0.5)
                            ),
                        new Shoot(16, predictive: 1, projectileIndex: 1, count: 5, shootAngle: 20, coolDown: 250),
                        new Shoot(20, predictive: 1, projectileIndex: 0, coolDown: 100),
                        new HpLessTransition(0.4, "blaarg3")
                        ), 
                        new State("blaarg3",
                        new Prioritize(
                            new Follow(0.3)
                            ),
                        new Grenade(1, 300, 12),
                        new Shoot(33, predictive: 1, projectileIndex: 1, count: 10, shootAngle: 15, coolDown: 650),
                        new HpLessTransition(0.2, "ragep")
                        ),
                    new State("ragep",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xfFF0000, 2, 9000001),
                        new TimedTransition(8000, "deathiscruel")
                        ),
                    new State("blaarg3",
                        new Prioritize(
                            new Follow(0.3)
                            ),
                        new Grenade(2, 195, 9),
                        new Shoot(20, projectileIndex: 1, count: 5, shootAngle: 50, coolDown: 350),
                        new Shoot(30, predictive: 1, projectileIndex: 1, count: 2, shootAngle: 35, coolDown: 150)
                        )
                    ),
                new MostDamagers(2,
                    new ItemLoot("Potion of Life", 0.5),
                    new ItemLoot("Potion of Health", 0.0001), //w0w
                    new ItemLoot("Potion of Vitality", 1.0)
                ),
                new Threshold(0.025,
                    new TierLoot(6, ItemType.Ring, 0.025),
                    new TierLoot(13, ItemType.Armor, 0.025),
                    new TierLoot(12, ItemType.Weapon, 0.025),
                    new TierLoot(6, ItemType.Ring, 0.025)
                )
            )
            ;
    }
}
