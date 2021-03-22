# Colony Bot

## Planned functionalities
The bot have several commands that are used to permit to player to make some actions
in order to involve in the Colony formed by a channel:

- Gather resources
- Build things
- Go to exploration to find rare resources and others

For the time being that's all !

## Dev notes

> **The need**: For the time being, the collection of all the ColonyMember instances is stored in the ColonyManager instance. I need to get the ColonyMember
instance that is attached to a DiscordUser instance at any time when a command is invoked in order to operate changes or consult its state.

+ How can I manage communications between the core game and the Discord command interface ?:
    + Make a Singleton out of the ColonyManager
    + Make a static class out of the ColonyManager
    + Another idea that not involve a global instance or a global 'utils' class