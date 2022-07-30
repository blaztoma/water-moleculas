mergeInto(LibraryManager.library, {

  setAnswer: function (number, correct_nr, answer_nr, is_correct) {
    is_correct = UTF8ToString(is_correct);
    //console.log(number + " " + correct_nr + " " + answer_nr + " " + is_correct);
      if(is_correct == "true") 
      {
        is_correct = "correct";
        rawScore++;
      } else 
      {
        is_correct = "wrong";
      }
      scorm.SetInteractionValue("cmi.interactions." + number + ".id","key" + number + "b20");
      scorm.SetInteractionValue("cmi.interactions." + number + ".type","choice");
      scorm.SetInteractionValue("cmi.interactions." + number + ".correct_responses.0.pattern", correct_nr);

      scorm.SetInteractionValue("cmi.interactions." + number + ".student_response",answer_nr);
      scorm.SetInteractionValue("cmi.interactions." + number + ".result", is_correct);


  },

  saveScore: function () {
    actualScore = Math.round(rawScore / numQuestions * 100);
    scorm.SetScoreRaw(actualScore+"" );
    //scorm.save();
  },

  setScore: function () {
    computeTime();  // the student has stopped here.

    //console.log(actualScore);
    //console.log(rawScore);
    actualScore = Math.round(rawScore / numQuestions * 100);
    var msg_str ="Your score is %d%%";            
    //console.log(msg_str.replace("%d",actualScore).replace("%%","%"));  

    scorm.SetScoreRaw(actualScore+"" );
    scorm.SetScoreMax(100);
    scorm.SetScoreMin(0);

    var mode = scorm.GetMode();

    if ( mode != "review"  &&  mode != "browse" ){
      if ( actualScore < 50 )
      {
        scorm.SetCompletionScormActivity("incomplete");
        scorm.SetSuccessStatus("failed");
        if (scorm.version == '2004') {
            scorm.SetInteractionValue("cmi.score.scaled", actualScore/100);
        }
      }
      else
      {
        scorm.SetCompletionScormActivity("completed");
        scorm.SetSuccessStatus("passed");
        if (scorm.version == '2004') {
            scorm.SetInteractionValue("cmi.score.scaled", actualScore/100);
        }
      }
    
      scorm.SetExit("");
    }
             
    exitPageStatus = true;

    scorm.save();
    scorm.quit();
  },

});