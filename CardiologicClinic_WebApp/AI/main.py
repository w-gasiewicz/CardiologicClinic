from keras.models import Sequential
from keras.layers import Dense
from keras.callbacks import History
from keras.models import load_model
import numpy as np
import matplotlib.pyplot as plt
# fix random seed for reproducibility
np.random.seed(7)
import pandas as pd
from sklearn.model_selection import train_test_split
from keras import optimizers

def Save(model):
    model.save('medical_module.h5')

def LoadModel():
    model = load_model('medical_module.h5')
    return model

def PredictPatientData(model):    
    # load input
    data = np.loadtxt('./predict.txt', delimiter=";", dtype=np.int)
    predict = model.predict_classes(np.array([data,]))  
    #predict2 = model.predict(np.array([data,]))  
    #print(predict)
    return predict

def DrawPlots(history):    
    # summarize history for accuracy
    plt.plot(history.history['accuracy'])
    plt.plot(history.history['val_acc'])
    plt.title('model accuracy')
    plt.ylabel('accuracy')
    plt.xlabel('epoch')
    plt.legend(['train', 'test'], loc='upper left')
    plt.show()
    # summarize history for loss
    plt.plot(history.history['loss'])
    plt.plot(history.history['val_loss'])
    plt.title('model loss')
    plt.ylabel('loss')
    plt.xlabel('epoch')
    plt.legend(['train', 'test'], loc='upper left')
    plt.show()

def Training():
#read data
    data = pd.read_csv("./danecsvintH.csv", sep=";")

#delete rows with missing data
#data = data[data.ca != '?']
#data = data[data.thal != '?']

#split data to training and test set (80-20)
    X_train_df, X_test_df = train_test_split(data, test_size=0.2, shuffle=True)

#creating output classes
    Y_train_df = X_train_df['num']
    Y_test_df = X_test_df['num']

#deleting output classes from training data
    X_train_df = X_train_df.drop(['num'], axis = 1)
    X_test_df = X_test_df.drop(['num'], axis = 1)

#converting from datafram to numpy array
    X_train = X_train_df.values
    X_test = X_test_df.values
    Y_train = Y_train_df.values
    Y_test = Y_test_df.values

#casting values to int
    X_train = X_train.astype('int')
    X_test = X_test.astype('int')
    Y_train = Y_train.astype('int')
    Y_test = Y_test.astype('int')

# create model
    model = Sequential()

# records events into a History object
    history = History()

#layers of the model
# relu -> activation(x) = max(0,x)
    model.add(Dense(13, input_dim=59, activation='relu'))
    model.add(Dense(8, activation='relu'))
    model.add(Dense(8, activation='relu'))
#model.add(Dense(5, activation='relu'))
#model.add(Dense(5, activation='relu'))
#model.add(Dense(1, activation='sigmoid'))
    model.add(Dense(5, activation='sigmoid'))

#optymalizer settings, in this examlpe we changed default learning rate
    adam = optimizers.Adam(lr=0.002)

#configurate model and picking optymalizer, loss function and metrics.
    model.compile(loss='sparse_categorical_crossentropy', optimizer=adam, metrics=['accuracy'])

# Start learning
# batch_size is number of samples per gradient update
# epoch is an iteration over the entire data provided
#fit - train data

    model.fit(X_train, Y_train, epochs=150, batch_size=10, callbacks=[history])

# evaluate the model
# acc = number of correct pred / total num of pred
    scores = model.evaluate(X_test, Y_test)
    print(model.summary())
    print("\n%s: %.7f%%" % (model.metrics_names[1], scores[1]*100))

#check model acc and save
    filer = open("bestacc.txt","r") 
    actualResult = filer.read()
    print("\n aktualny najlepszy model: %s"%(actualResult))
    filer.close()
    aRF = float(actualResult)
    
    if(aRF < scores[1]*100):
        filew = open("bestacc.txt","w") 
        filew.write(str(scores[1]*100)) 
        filew.close()
        Save(model)
        print("Zapisano pomyślnie nowy lepszy model! acc = %.7f%%"(scores[1]*100))

    PredictPatientData(model)
    #DrawPlots(history)

def main():
    Training()
    #model = LoadModel()
    #result = PredictPatientData(model)

    #filew = open("output.txt","w") 
    #filew.write(str(result[0])) 
    #filew.close()
    #print (str(result[0]))

if __name__ == "__main__":
    main()