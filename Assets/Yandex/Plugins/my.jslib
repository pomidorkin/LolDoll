mergeInto(LibraryManager.library, {

  Hello: function() {
    window.alert("Hello, world!");
  },

  UpdateLeaderboard: function(value) {
    ysdk.getLeaderboards()
  .then(lb => {
    lb.setLeaderboardScore('TotalDolls', value);
  });
  },


  SaveExtern: function(data) {
      var dateString = UTF8ToString(data);
      var myobj = JSON.parse(dateString);
      player.setData(myobj);
    },


    LoadExtern: function(){
      player.getData().then(_data => {
          const myJSON = JSON.stringify(_data);
          myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
      });
  },

  RateGame: function() {
ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                      myGameInstance.SendMessage('Yandex', 'DisableRateGameButton');
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
    
  },

  CheckCanReview: function() {
ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
              myGameInstance.SendMessage("Yandex", "EnableRateGameButton");
              console.log('Can review');
            } else {
              console.log('Cannot review');
                console.log(reason)
            }
        })
    
  },

  ShowAdv: function() {
ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          myGameInstance.SendMessage("Yandex", "UnpauseAudio");
        },
        onError: function(error) {
          myGameInstance.SendMessage("Yandex", "UnpauseAudio");
        }
    }
})
    
  },

  AddCoinsExtern: function(value) {
ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
        },
        onClose: () => {
          console.log('Video ad closed.');
          myGameInstance.SendMessage("Yandex", "UnpauseAudio");
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
          myGameInstance.SendMessage("Yandex", "UnpauseAudio");
        }
    }
})
    

  },

  UnblockTrackExtern: function() {
ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage("PurchasePopupManager", "UnlockTrackSuccess");
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
    

  },


});