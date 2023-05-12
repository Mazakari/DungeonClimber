mergeInto(LibraryManager.library, {

  GetPlayerIDData: function () {
	  myGameInstance.SendMessage('YandexAPI', 'SetPlayerIDName', player.getName());
	  myGameInstance.SendMessage('YandexAPI', 'SetPlayerIDAvatar', player.getPhoto("medium"));
    },
	
	RateGame: function () {
	 ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
    },
	
  });