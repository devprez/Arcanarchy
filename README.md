# Arcanarchy

A Unity/C# slot-machine prototype built around tarot-inspired symbols, configurable reel strips, deterministic testing, and expandable game math.

Arcanarchy is a portfolio project exploring slot-engine architecture, probability, payout logic, UI presentation, and eventually adaptive music and bonus mechanics.

## Current Features

- 5 × 3 reel grid
- Tarot-inspired symbol set
- Configurable reel strips
- Seeded random number generation for reproducible testing
- Core spin engine separated from presentation logic
- Payline evaluation
- Wild symbol support
- Large-scale RTP simulation / audit tooling
- Unity-based visual presentation

## Math / Testing

The project includes a dedicated slot math engine and test harness so game behavior can be evaluated independently of the Unity presentation layer.

A 100,000-spin audit of the current build produced approximately:

- **RTP:** 90.88%
- **Hit Rate:** 38.48%
- **Largest Win:** 600 credits

These values reflect the current prototype configuration and will change as paylines, symbol weights, payouts, and bonus systems evolve.

## Tech

- **Unity**
- **C#**
- Deterministic / seeded random testing
- Data-driven reel configuration
- Separation of game logic and presentation
- Git / GitHub

## Architecture

The core slot logic is designed to stay independent from the Unity UI.

`SlotMathEngine` generates reel results using configurable reel strips and an injected random source, making the system easier to test, simulate, and extend.

This allows the project to support:

- automated math testing
- reproducible spin sequences
- future payout-table experimentation
- additional paylines and bonus mechanics
- alternate front ends or presentation layers

## In Development

- Expanded payline set
- **Break the Wheel** bonus feature
- Final tarot card artwork
- Improved animation and presentation
- Adaptive music and sound design
- WebGL build / playable demo
- Additional math balancing and audit tools

## Portfolio Goal

Arcanarchy is primarily a technical and game-design portfolio project demonstrating:

- C# architecture
- probability and game math
- testable systems design
- Unity development
- iterative gameplay development
- audio / visual integration

## Status

Active development.

Artwork, balancing, audio, and bonus systems are still evolving.
