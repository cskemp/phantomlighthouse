
## Experiment 1 Data

The experiment used a 100m measuring tape stretched out on the beach. 0 m along the tape corresponds to the 90m position in Figure 4a, and 100m along the tape corresponds to the 154 m position in Figure 4a. All positions in the data file are with respect to the measuring tape rather than the labels in Figure 4a.

`expt1_field.csv` includes the following columns:

  * `Participant Number`: participant id
  * `Date`: date on which participant took the task
  * `Age`: participant age in years
  * `Gender`
  * `Visual Aids`: indicates whether participant wore glasses, contacts, or no visual aids
  * `First`: 100 indicates that the participant started 100m along the tape, and 0 indicates that the person started 0m along the tape. 
  * `d_0`, `d_20`, `d_40`, `d_60`, `d_80`, `d_100`: responses at the 6 positions along the tape. `B` indicates that the source is judged to be behind and `F` indicates that the source is judged to be in front.
  * `Sketch`: `Down` if the sketch pointed Down.
  * `Shape`: Response to the multiple choice question (is the beam curving up, horizontal, or curving down?)
  * `Comments`: Free text field including additional observations.


`expt1_sketches.pdf` includes sketches made by the eight participants.


## Experiment 2 Data

`expt2_vr.csv` includes the following columns:

  * `name`: randomly generated identifier used to name the data file for this participant
  * `illusion`: condition which could be `demo` (2 spheres), `phantom` (phantom condition), `bbhoriz` (bent beam horizontal condition), or `bbdepth` (bent beam depth condition)
  * `method`: `sc` (staircase) or `adj` (adjustment)
  * `id`: combines `illusion` and `method`
  * `data`: variable value (e.g. separation or angle depending on condition)
  * `time`: elapsed time in seconds
  * `minutes`: elapsed time in minutes
  * `trial`: estimate number (e.g. there were 2 staircase estimates and 4 adjustment estimates per condition)
  * `count`: response number within the current estimate
  * `inflection`: indicates whether the current response is an inflection point: -1 indicates increasing -> decreasing, 1 indicates decreasing -> increasing, and 0 indicates no inflection.    * `benchmark`: benchmark value for current condition (e.g. 75 m for phantom condition)

