from keras.models import Sequential
from keras.layers import Dense
from keras.callbacks import History
from keras.models import load_model
from keras.utils import plot_model
import numpy as np
import sklearn.feature_selection as feat_select
import matplotlib.pyplot as plt
from numpy import genfromtxt
# fix random seed for reproducibility
np.random.seed(7)
import pandas as pd
from sklearn.model_selection import train_test_split
from keras import optimizers

def Save(model):
    model.save('medical_module.h5')

def DrawPlots(history): 
    # summarize history for accuracy
    plt.plot(history.history['accuracy'])
    plt.plot(history.history['val_accuracy'])
    plt.title('model accuracy')
    plt.ylabel('accuracy')
    plt.xlabel('epoch')
    plt.legend(['train', 'test'], loc='upper left')
    plt.savefig('../wwwroot/images/acc.png')
    #plt.show()

    # summarize history for loss
    plt.plot(history.history['loss'])
    plt.plot(history.history['val_loss'])
    plt.title('model loss')
    plt.ylabel('loss')
    plt.xlabel('epoch')
    plt.legend(['train', 'test'], loc='upper left')
    plt.savefig('../wwwroot/images/loss.png')
    #plt.show()

def Training():
#read data
    #data = pd.read_csv("./danecsvintH.csv", sep=";")
    my_data = genfromtxt('danecsvintH.csv', delimiter=';')
    test = feat_select.SelectKBest(score_func=feat_select.chi2, k=51)
    X = my_data[1:, 0:59].astype('int')
    Y = my_data[1:, 59].astype('int')
    data = test.fit_transform(X, Y)
    res = []
    for i in range(len(Y)):
        res.append([Y[i]])
    Y = res
    data = np.append(data, Y, axis=1)
#split data to training and test set (80-20)
    train_df, test_df = train_test_split(data, test_size=0.2, shuffle=True)

#creating output classes
    Y_train = train_df[:,len(train_df[0])-1]
    Y_test = test_df[:,len(test_df[0])-1]

#deleting output classes from training data
    X_train = train_df[:,0:len(train_df[0])-1]
    X_test = test_df[:,0:len(test_df[0])-1]

# create model
    model = Sequential()

#layers of the model
# relu -> activation(x) = max(0,x)
    model.add(Dense(13, input_dim=len(X_train[0]), activation='relu'))
    model.add(Dense(8, activation='relu'))
    model.add(Dense(8, activation='relu'))
    model.add(Dense(5, activation='softmax'))

#optymalizer settings, in this examlpe we changed default learning rate
    adam = optimizers.Adam(lr=0.002)

#configurate model and picking optymalizer, loss function and metrics.
    model.compile(loss='sparse_categorical_crossentropy', optimizer=adam, metrics=['accuracy'])

# batch_size is number of samples per gradient update
# epoch is an iteration over the entire data provided
#fit - train data
    history = model.fit(X_train, Y_train, epochs=200, batch_size=10, validation_data=(X_test, Y_test))

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
        print("Zapisano pomyślnie nowy lepszy model! acc = "+str(scores[1]*100))
        import os
        os.environ["PATH"] += os.pathsep + 'C:/Program Files (x86)/Graphviz2.38/bin/'
        plot_model(model, show_shapes=True, show_layer_names=True, to_file='model.png')
        DrawPlots(history)

def main():
    Training()

if __name__ == "__main__":
    main()