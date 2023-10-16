INSERT INTO `Experiments` (`Id`, `Name`)
      VALUES (1, "button_color");
INSERT INTO `Experiments` (`Id`, `Name`)
      VALUES (2, "price");
      

INSERT INTO `ExperimentOption` (`ExperimentId`, `Probability`, `Value`)
      VALUES (1, 33.3, "#FF0000");
INSERT INTO `ExperimentOption` (`ExperimentId`, `Probability`, `Value`)
      VALUES (1, 33.3, "#00FF00");
INSERT INTO `ExperimentOption` (`ExperimentId`, `Probability`, `Value`)
      VALUES (1, 33.3, "#0000FF");
INSERT INTO `ExperimentOption` (`ExperimentId`, `Probability`, `Value`)
      VALUES (2, 75, 10);   
INSERT INTO `ExperimentOption` (`ExperimentId`, `Probability`, `Value`)
      VALUES (2, 10, 20);
INSERT INTO `ExperimentOption` (`ExperimentId`, `Probability`, `Value`)
      VALUES (2, 5, 50);    
INSERT INTO `ExperimentOption` (`ExperimentId`, `Probability`, `Value`)
      VALUES (2, 10, 10);