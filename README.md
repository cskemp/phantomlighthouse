Code, data, and materials for Kemp, Xu and Cropper, A Bayesian account of the Phantom Lighthouse Illusion

## Lighthouse
Source code for the Unity experiment (Experiment 2). To run this you'll need to have Unity and the Unity Hub installed on your machine. We used Unity Editor version 2021.3.18f1 

## model 
Code for computing model predictions

## movies
Screen recordings for separations between observer and lighthouse of 0m, 67 m and 300 m.

## analysis
Notebook containing analyses for the VR experiment (`analyze_expt_vr.Rmd`) and a field experiment that is not included in the current version of the paper (`analyze_expt_field.Rmd`)

## data
Data for the VR experiment (`expt_vr.csv') and the field experiment 
(`expt_field.csv`)

## materials
Questions given to participants as part of the field experiment. Materials for the VR experiment are represented by the source code in `Lighthouse/`

## Installing R Libraries

From within R, run

`> renv::restore()`

to install packages used by the code in this repository

## Python version

This code was developed using Python 3.11. See `environment.yml` for a full specification of the environment used.

