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
	
	SavePlayerDataToYandex: function (playerData) {
	  var dataString = UTF8ToString(playerData);
	  var myObj = JSON.parse(dataString);
	  player.setData(myObj);
	  console.log(dataString);
	  console.log(myObj);
    },
	
	LoadPlayerDataFromYandex: function () {
	 player.getData().then(_data => {
		 const myJSON = JSON.stringify(_data);
		 myGameInstance.SendMessage('YandexAPI', 'CopyYandexProgress', myJSON);
		 
	 });
    },
	
  });