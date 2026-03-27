# Heatwave Digital Twin Simulation

This project simulates heat exposure scenarios using the BioGears physiology engine and visualizes the results in Unity.

## Architecture

Scenario Generator
→ BioGears Simulation Engine
→ CSV Data Processing
→ Unity Visualization

## Components

scenario-generator/
Creates BioGears scenario XML files.

simulation-runner/
Runs BioGears simulations.

data-processor/
Parses CSV output and streams data.

unity-dashboard/
Unity frontend for visualization.

## Physiological Variables

- Heart Rate
- Core Temperature
- Skin Temperature
- Respiration Rate
- Oxygen Saturation