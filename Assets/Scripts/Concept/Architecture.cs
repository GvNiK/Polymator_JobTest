namespace DefaultNamespace.Concept
{
    public class Architecture
    {
        /*
        1. CarPart - Name & GameObject
        2. IAnimate - Methods - Start, Stop and IsAnimating bool
        3. Bonnet - Implements CarPart or List<CarPart> & IAnimate
        & has Vector3 for Rotation or Translation. Ex:- Bonnet X: 45 Open & X:0 Close
        4. Same with Trunk, Doors and Tyres.
        5. InteractionAnimationManager - Manages the animation of the bonnet, trunk, etc classes
        6. InteractionUIManager - Manages the UI INteraction.
        7. InteractionManager - Main Class. Stores Animation & UI manager classes
        */
    }
}